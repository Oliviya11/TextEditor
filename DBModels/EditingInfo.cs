using System;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class EditingInfo
    {
        #region Fields
        private Guid _guid;
        private string _filePath;
        private bool _isFileChanged;
        private DateTime _editingDate;
        #endregion

        #region Properties
        [DataMember]
        public Guid Id {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
            }
        }

        [DataMember]
        public string FilePath {
            get
            {
                return _filePath;
            }
            private set
            {
                _filePath = value;
            }
        }

        [DataMember]
        public bool IsFileChanged
        {
            get
            {
                return _isFileChanged;
            }
            private set
            {
                _isFileChanged = value;
            }
        }

        [DataMember]
        public DateTime EditingDate
        {
            get
            {
                return _editingDate;
            }
            private set
            {
                _editingDate = value;
            }
        }
        #endregion

        #region Construcor
        public EditingInfo(string filePath, bool isFileChanged, DateTime editingDate)
        {
            _guid = Guid.NewGuid();
            _filePath = filePath;
            _isFileChanged = isFileChanged;
            _editingDate = editingDate;
        }

        public EditingInfo() { }
        #endregion

        public override string ToString()
        {
            return $"{FilePath} {EditingDate} {IsFileChanged}";
        }

        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public User User { get; set; }
    }
}
