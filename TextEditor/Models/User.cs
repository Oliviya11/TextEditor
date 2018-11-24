using System;
using System.Collections.Generic;
using System.Windows;
using TextEditor.utils;

namespace TextEditor.Models
{
    [Serializable]
    public class User
    {
        #region Const
        [NonSerialized]
        private const string PrivateKey = "<RSAKeyValue><Modulus>sr4l8EwMgPqPhRTK+dPTwGs9uYhDeUohSRL48ZDf85/5/Lo469WltKFaQvA2Msy92xq14YPPN6p6mQD7stVbinRd+hihnYoqfclYRMe+FG6jqu/QACl0N6JgwM7iKGiyzBjL1vkvcSoaqwbxD8QPHgrdNlkyP0z6Vz7j79PFEos=</Modulus><Exponent>AQAB</Exponent><P>6OkjEhjlvbDCuOl8e0Ep2zACTxkfSta8WFBmdvrinhQSowkT5xDXL0EFa/Z03XNUmjJ0xGe1aNCgG+6dDpTnSw==</P><Q>xHZTH4hXAv7uJsb/VHrcYOM5l4AyC+OxP7bhmAoGJGf4TpPxh+B0RhMxssrkc1d/72TIfRpuPbSLEqkqCSk5wQ==</Q><DP>SKFzK1CSTB4UCv/crr76Y3zMK4hlBryCDXQ9D7ta8frGeQr6puLMh9LZ8vnvJaOybUdwvFKu8pmkZDF7zrFGkw==</DP><DQ>J3ZNBAxyzds/IvLd3q4/DgcWTmQlqVW3CMFHVy7MRQvNSJtW7KAdOuYoGW2/rZtpy0BHNTnV4vcc6EaqduSdAQ==</DQ><InverseQ>4/jjapjJHdDqr5FG5a29ISgO6mRnjty6nrOisPNDi4336JdEKfAdtZvDUQoBAwKsV0oMvJ9RtPB2tS0hf5i8pA==</InverseQ><D>qcnyY/b5kbNxjasYvIQ5i3jTY2BLJ/YA9FcvXtiNw/DdGPMUiwGhrJnxEdD4yvyuBGm1CAmbV3d7icfjUBdYIe9VaZqPQ2FgYzI5DbB401+4z6Di7uKBVajLIOawlnufW4+K68T0EAFO2l9eo1RcU66W921G/pz6hObeUXt65QE=</D></RSAKeyValue>";
        [NonSerialized]
        private const string PubblicKey = "<RSAKeyValue><Modulus>sr4l8EwMgPqPhRTK+dPTwGs9uYhDeUohSRL48ZDf85/5/Lo469WltKFaQvA2Msy92xq14YPPN6p6mQD7stVbinRd+hihnYoqfclYRMe+FG6jqu/QACl0N6JgwM7iKGiyzBjL1vkvcSoaqwbxD8QPHgrdNlkyP0z6Vz7j79PFEos=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        #endregion

        #region Fields
        [NonSerialized]
        private Guid _guid;
        private string _login;
        private string _name;
        private string _surname;
        private string _password;
        private string _email;

        #endregion

        #region Properties
        [System.Xml.Serialization.XmlIgnore]
        public Guid Id
        {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set { }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            private set { }
        }

        private string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            private set { }
        }
        #endregion

        #region Constructor
        public User(string login, string name, string surname, string password, string email)
        {
            _guid = Guid.NewGuid();
            _login = login;
            _name = name;
            _surname = surname;
            _email = email;
            SetPassword(password);
        }

        public User() { }
        #endregion

        private void SetPassword(string password)
        {
            _password = Encrypting.EncryptText(password, PubblicKey);
        }
        public bool CheckPassword(string password)
        {
            try
            {
                string res = Encrypting.DecryptString(_password, PrivateKey);
                string res2 = Encrypting.GetMd5HashForString(password);
                return res == res2;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Login}";
        }

        [System.Xml.Serialization.XmlIgnore]
        public List<EditingInfo> EditingInfos { get; set; }

       
    }
}
