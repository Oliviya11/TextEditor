using System;
using System.Runtime.Serialization;

namespace DBModels
{
    [DataContract(IsReference = true)]
    public class EditingInfo
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _filePath;
        [DataMember]
        private bool _isFileChanged;
        [DataMember]
        private DateTime _editingDate;
        #endregion

        #region Properties
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
        private bool IsFileChanged
        {
            get
            {
                return _isFileChanged;
            }
            set
            {
                _isFileChanged = value;
            }
        }
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

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
