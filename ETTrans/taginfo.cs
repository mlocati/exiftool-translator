
namespace ETTrans {
    using System.Xml.Serialization;
    
    
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute("taginfo", IsNullable=false)]
    public partial class taginfoType {
        
        private tableType[] tableField;
        
        [System.Xml.Serialization.XmlElementAttribute("table")]
        public tableType[] table {
            get {
                return this.tableField;
            }
            set {
                this.tableField = value;
            }
        }
    }
    
    [System.SerializableAttribute()]
    public partial class tableType {
        
        private descType[] descField;
        
        private tagType[] tagField;
        
        private string nameField;
        
        private string g0Field;
        
        private string g1Field;
        
        private string g2Field;
        
        [System.Xml.Serialization.XmlElementAttribute("desc")]
        public descType[] desc {
            get {
                return this.descField;
            }
            set {
                this.descField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("tag")]
        public tagType[] tag {
            get {
                return this.tagField;
            }
            set {
                this.tagField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string g0 {
            get {
                return this.g0Field;
            }
            set {
                this.g0Field = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string g1 {
            get {
                return this.g1Field;
            }
            set {
                this.g1Field = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string g2 {
            get {
                return this.g2Field;
            }
            set {
                this.g2Field = value;
            }
        }
    }
    
    [System.SerializableAttribute()]
    public partial class descType {
        
        private string langField;
        
        private string valueField;
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string lang {
            get {
                return this.langField;
            }
            set {
                this.langField = value;
            }
        }
        
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    [System.SerializableAttribute()]
    public partial class valType {
        
        private string langField;
        
        private string valueField;
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string lang {
            get {
                return this.langField;
            }
            set {
                this.langField = value;
            }
        }
        
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    [System.SerializableAttribute()]
    public partial class keyType {
        
        private valType[] valField;
        
        private string idField;
        
        [System.Xml.Serialization.XmlElementAttribute("val")]
        public valType[] val {
            get {
                return this.valField;
            }
            set {
                this.valField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
    
    [System.SerializableAttribute()]
    public partial class valuesType {
        
        private keyType[] keyField;
        
        private int indexField;
        
        private bool indexFieldSpecified;
        
        [System.Xml.Serialization.XmlElementAttribute("key")]
        public keyType[] key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int index {
            get {
                return this.indexField;
            }
            set {
                this.indexField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool indexSpecified {
            get {
                return this.indexFieldSpecified;
            }
            set {
                this.indexFieldSpecified = value;
            }
        }
    }
    
    [System.SerializableAttribute()]
    public partial class tagType {
        
        private descType[] descField;
        
        private valuesType[] valuesField;
        
        private string idField;
        
        private string nameField;
        
        private int indexField;
        
        private bool indexFieldSpecified;
        
        private string typeField;
        
        private int countField;
        
        private bool countFieldSpecified;
        
        private bool writableField;
        
        private string g0Field;
        
        private string g1Field;
        
        private string g2Field;
        
        [System.Xml.Serialization.XmlElementAttribute("desc")]
        public descType[] desc {
            get {
                return this.descField;
            }
            set {
                this.descField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("values")]
        public valuesType[] values {
            get {
                return this.valuesField;
            }
            set {
                this.valuesField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int index {
            get {
                return this.indexField;
            }
            set {
                this.indexField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool indexSpecified {
            get {
                return this.indexFieldSpecified;
            }
            set {
                this.indexFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int count {
            get {
                return this.countField;
            }
            set {
                this.countField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool countSpecified {
            get {
                return this.countFieldSpecified;
            }
            set {
                this.countFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool writable {
            get {
                return this.writableField;
            }
            set {
                this.writableField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string g0 {
            get {
                return this.g0Field;
            }
            set {
                this.g0Field = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string g1 {
            get {
                return this.g1Field;
            }
            set {
                this.g1Field = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string g2 {
            get {
                return this.g2Field;
            }
            set {
                this.g2Field = value;
            }
        }
    }
}

