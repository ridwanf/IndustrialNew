using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Industrial.Infrastructure.Utility;

namespace Industrial.Data.Domain
{
    public class User : BaseClass<Guid>
    {
        private string _encryptedPassword;
        private string _password;

        public string EncryptedPassword
        {
            get { return _encryptedPassword; }
            set
            {
                _encryptedPassword = value;
                _password = Util.DecryptValue(_encryptedPassword);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                _encryptedPassword = Util.Encrypt(_password);
            }
        }


        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        #region Public Properties

        /// <summary>
        ///     Gets or sets the selected theme by the user.
        /// </summary>
        public string SelectedTheme { get; set; }

        /// <summary>
        ///     Gets or sets the selected accent by the user.
        /// </summary>
        public string SelectedAccent { get; set; }

        /// <summary>
        ///     Gets or sets the user's picture.
        /// </summary>
        public byte[] Picture { get; set; }

        #endregion

   
    }
}