using System;
using System.Collections.Generic;
using System.Text;

namespace ETTrans
{
	public class TagInfoUI
	{
		private string _filename;
		private taginfoType _taginfo;
		private Dictionary<string, Dictionary<string, List<string>>> _groups;
		private Dictionary<string, string> _languages;
		public string Filename
		{
			get
			{
				return this._filename;
			}
		}
		public Dictionary<string, Dictionary<string, List<string>>> Groups
		{
			get
			{ return this._groups; }
		}
		public Dictionary<string, string> Languages
		{
			get
			{ return this._languages; }
		}
		public TagInfoUI(string filename)
		{
			this._filename = filename;
			this._taginfo = taginfoType.Deserialize(this._filename);
			this._groups = new Dictionary<string, Dictionary<string, List<string>>>();
			List<string> languages = new List<string>();
			foreach (tableType table in this._taginfo.table)
			{
				if (!this._groups.ContainsKey(table.g0))
				{
					this._groups.Add(table.g0, new Dictionary<string, List<string>>());
				}
				if (!this._groups[table.g0].ContainsKey(table.g1))
				{
					this._groups[table.g0].Add(table.g1, new List<string>());
				}
				if (!this._groups[table.g0][table.g1].Contains(table.g2))
				{
					this._groups[table.g0][table.g1].Add(table.g2);
				}
				if (table.desc != null)
				{
					foreach (descType desc in table.desc)
					{
						if (!languages.Contains(desc.lang))
						{
							languages.Add(desc.lang);
						}
					}
					if (table.tag != null)
					{
						foreach (tagType tag in table.tag)
						{
							if (tag.desc != null)
							{
								foreach (descType desc in tag.desc)
								{
									if (!languages.Contains(desc.lang))
									{
										languages.Add(desc.lang);
									}
								}
							}
							if (tag.values != null)
							{
								foreach (valuesType values in tag.values)
								{
									if (values.key != null)
									{
										foreach (keyType key in values.key)
										{
											if (key.val != null)
											{
												foreach (valType val in key.val)
												{
													if (!languages.Contains(val.lang))
													{
														languages.Add(val.lang);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			List<KeyValuePair<string, string>> languagesWithNames = new List<KeyValuePair<string, string>>();
			foreach (string language in languages)
			{
				languagesWithNames.Add(new KeyValuePair<string, string>(language, Utils.GetLanguageName(language)));
			}
			languagesWithNames.Sort(delegate(KeyValuePair<string, string> a, KeyValuePair<string, string> b)
			{
				return string.Compare(a.Value, b.Value, true);
			});
			this._languages = new Dictionary<string, string>(languagesWithNames.Count);
			foreach (KeyValuePair<string, string> kv in languagesWithNames)
			{
				this._languages.Add(kv.Key, kv.Value);
			}
		}
		public List<TranslateItem> GetTranslateTable(frmMain form, string g0, string g1, string g2, string languageReference, string languageTranslate, bool valuesToo)
		{
			TagTranslateItem ttItem;
			List<TranslateItem> items = new List<TranslateItem>();
			foreach (tableType table in this._taginfo.table)
			{
				if
				(
					(string.IsNullOrEmpty(g0) || string.Equals(table.g0, g0, StringComparison.InvariantCultureIgnoreCase))
					&&
					(string.IsNullOrEmpty(g1) || string.Equals(table.g1, g1, StringComparison.InvariantCultureIgnoreCase))
					&&
					(string.IsNullOrEmpty(g2) || string.Equals(table.g2, g2, StringComparison.InvariantCultureIgnoreCase))
				)
				{
					items.Add(new TableTranslateItem(form, languageReference, languageTranslate, table));
					if (table.tag != null)
					{
						foreach (tagType tag in table.tag)
						{

							items.Add(ttItem = new TagTranslateItem(form, languageReference, languageTranslate, table, tag));
							if (valuesToo && (tag.values != null))
							{
								foreach (valuesType values in tag.values)
								{
									if (values.key != null)
									{
										foreach (keyType key in values.key)
										{
											items.Add(new KeyTranslateItem(form, languageReference, languageTranslate, values, key, string.Format("{0} > ", ttItem.ID)));
										}
									}
								}
							}
						}
					}
				}
			}
			return items;
		}
		public void Save()
		{
			this.SaveAs(this._filename);
		}
		public void SaveAs(string filename)
		{
			this._taginfo.Serialize(filename);
			this._filename = filename;
		}
	}
	public abstract class TranslateItem
	{
		protected frmMain _form;
		protected readonly string LangRef;
		protected readonly string LangTrans;
		protected string _id;
		public string ID
		{
			get
			{ return this._id; }
		}
		protected string _ref;
		public string Ref
		{
			get
			{ return this._ref; }
		}
		public abstract string Trans { get; set; }
		public virtual string Values
		{
			get
			{
				return "";
			}
		}
		protected TranslateItem(frmMain form, string langRef, string langTrans)
		{
			this._form = form;
			this.LangRef = langRef;
			this.LangTrans = langTrans;
		}
	}
	public abstract class DescsTranslateItem : TranslateItem
	{
		private Dictionary<string, descType> _descs;
		private descType GetLangDesc(string lang)
		{
			if (this._descs.ContainsKey(lang))
			{
				return this._descs[lang];
			}
			else
			{
				return null;
			}
		}
		public override string Trans
		{
			get
			{
				descType desc = this.GetLangDesc(this.LangTrans);
				return ((desc == null) || (desc.Value == null)) ? "" : desc.Value;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				if (string.Compare(value, this.Trans, false) == 0)
				{
					return;
				}
				descType desc = this.GetLangDesc(this.LangTrans);
				if (string.IsNullOrEmpty(value))
				{
					if (desc != null)
					{
						this.RemoveDesc(desc);
						this._descs.Remove(this.LangTrans);
					}
				}
				else
				{
					if (desc == null)
					{
						desc = new descType();
						desc.lang = this.LangTrans;
						desc.Value = value;
						this.AddDesc(desc);
						this._descs.Add(desc.lang, desc);
					}
					else
					{
						desc.Value = value;
					}
				}
				this._form.Dirty = true;
			}
		}
		protected abstract void AddDesc(descType desc);
		protected abstract void RemoveDesc(descType desc);
		protected DescsTranslateItem(frmMain form, string langRef, string langTrans, descType[] descs)
			: base(form, langRef, langTrans)
		{
			this._descs = new Dictionary<string, descType>((descs == null) ? 0 : descs.Length);
			if (descs != null)
			{
				foreach (descType desc in descs)
				{
					this._descs.Add(desc.lang, desc);
				}
			}
			descType descRef = this.GetLangDesc(this.LangRef);
			this._ref = ((descRef == null) || (descRef.Value == null)) ? "" : descRef.Value;
		}
	}
	public class TableTranslateItem : DescsTranslateItem
	{
		private tableType _table;

		public TableTranslateItem(frmMain form, string langRef, string langTrans, tableType table)
			: base(form, langRef, langTrans, table.desc)
		{
			this._table = table;
			this._id = this._table.name;
		}
		protected override void AddDesc(descType desc)
		{
			if (this._table.desc == null)
			{
				this._table.desc = new descType[] { desc };
			}
			else
			{
				List<descType> descs = new List<descType>(this._table.desc.Length + 1);
				descs.AddRange(this._table.desc);
				descs.Add(desc);
				this._table.desc = descs.ToArray();
			}
		}
		protected override void RemoveDesc(descType desc)
		{
			List<descType> descs = new List<descType>(this._table.desc.Length);
			descs.AddRange(this._table.desc);
			descs.Remove(desc);
			this._table.desc = (descs.Count == 0) ? null : descs.ToArray();
		}
	}
	public class TagTranslateItem : DescsTranslateItem
	{
		private tableType _table;
		private tagType _tag;
		public readonly bool HasValues;
		public override string Values
		{
			get
			{
				if (this.HasValues)
				{
					return "edit";
				}
				else
				{
					return base.Values;
				}
			}
		}
		public TagTranslateItem(frmMain form, string langRef, string langTrans, tableType table, tagType tag)
			: base(form, langRef, langTrans, tag.desc)
		{
			this._table = table;
			this._tag = tag;
			this.HasValues = (tag.values != null) && (tag.values.Length > 0);
			this._id = string.Format("{0} > {1}", this._table.name, this._tag.name);
		}
		protected override void AddDesc(descType desc)
		{
			if (this._tag.desc == null)
			{
				this._tag.desc = new descType[] { desc };
			}
			else
			{
				List<descType> descs = new List<descType>(this._tag.desc.Length + 1);
				descs.AddRange(this._tag.desc);
				descs.Add(desc);
				this._tag.desc = descs.ToArray();
			}
		}
		protected override void RemoveDesc(descType desc)
		{
			List<descType> descs = new List<descType>(this._tag.desc.Length);
			descs.AddRange(this._tag.desc);
			descs.Remove(desc);
			this._tag.desc = (descs.Count == 0) ? null : descs.ToArray();
		}
		public List<KeyTranslateItem> GetTranslateValues()
		{
			if (!this.HasValues)
			{
				return null;
			}
			else
			{
				List<KeyTranslateItem> list = new List<KeyTranslateItem>();
				foreach (valuesType values in this._tag.values)
				{
					if (values.key != null)
					{
						foreach (keyType key in values.key)
						{
							list.Add(new KeyTranslateItem(this._form, this.LangRef, this.LangTrans, values, key));
						}
					}
				}
				return list;
			}

		}
	}
	public class KeyTranslateItem : TranslateItem
	{
		private valuesType _values;
		private keyType _key;
		private Dictionary<string, valType> _vals;
		public override string Trans
		{
			get
			{
				valType val = this.GetLangVal(this.LangTrans);
				return ((val == null) || (val.Value == null)) ? "" : val.Value;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				if (string.Compare(value, this.Trans, false) == 0)
				{
					return;
				}
				valType val = this.GetLangVal(this.LangTrans);
				if (string.IsNullOrEmpty(value))
				{
					if (val != null)
					{
						this.RemoveVal(val);
						this._vals.Remove(this.LangTrans);
					}
				}
				else
				{
					if (val == null)
					{
						val = new valType();
						val.lang = this.LangTrans;
						val.Value = value;
						this.AddVal(val);
						this._vals.Add(val.lang, val);
					}
					else
					{
						val.Value = value;
					}
				}
				this._form.Dirty = true;
			}
		}
		private valType GetLangVal(string lang)
		{
			if (this._vals.ContainsKey(lang))
			{
				return this._vals[lang];
			}
			else
			{
				return null;
			}
		}
		protected void AddVal(valType val)
		{
			if (this._key.val == null)
			{
				this._key.val = new valType[] { val };
			}
			else
			{
				List<valType> vals = new List<valType>(this._key.val.Length + 1);
				vals.AddRange(this._key.val);
				vals.Add(val);
				this._key.val = vals.ToArray();
			}
		}
		protected void RemoveVal(valType val)
		{
			List<valType> vals = new List<valType>(this._key.val.Length);
			vals.AddRange(this._key.val);
			vals.Remove(val);
			this._key.val = (vals.Count == 0) ? null : vals.ToArray();
		}

		public KeyTranslateItem(frmMain form, string langRef, string langTrans, valuesType values, keyType key)
			: this(form, langRef, langTrans, values, key, "")
		{ }
		public KeyTranslateItem(frmMain form, string langRef, string langTrans, valuesType values, keyType key, string preIdText)
			: base(form, langRef, langTrans)
		{
			this._values = values;
			this._key = key;
			this._vals = new Dictionary<string, valType>(((key.val == null) || (key.val.Length == 0)) ? 1 : key.val.Length);
			if (key.val != null)
			{
				foreach (valType val in key.val)
				{
					this._vals.Add(val.lang, val);
				}
			}
			valType valRef = this.GetLangVal(this.LangRef);
			this._id = string.Format("{0}{1}{2}", (preIdText == null) ? "" : preIdText, this._values.indexSpecified ? string.Format("{0:N0} > ", this._values.index) : "", this._key.id);
			this._ref = ((valRef == null) || (valRef.Value == null)) ? "" : valRef.Value;
		}
	}
}
