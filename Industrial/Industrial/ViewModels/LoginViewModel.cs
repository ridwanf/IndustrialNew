﻿/***************************************************************************************************
 * PROJECT : Industrial
 * PROJECT DESCRIPTION : A metro style, smart client expense tracking software.
 * AUTHOR : Siddhartha S
 * DISCLAIMER : This code is licensed under CPOL. You are free to use this in your project.
 * The author takes no liabilities for any damage caused because of this code. Use at your own risk.
****************************************************************************************************/

using System;
using System.Windows.Input;
using Industrial.Infrastructure.BaseClasses;
using Industrial.Infrastructure.CoreClasses;
using Industrial.Infrastructure.MessagingService;
using Industrial.Infrastructure.Utility;
using Industrial.Model.EventArgsAndException;
using Industrial.Models.EventArgsAndException;
using Industrial.Repository.Repositories;
using Industrial.Shared;

namespace Industrial.ViewModels
{
    /// <summary>
    /// The view model catering to the login view.
    /// </summary>
    public class LoginViewModel : WorkspaceViewModelBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessagingService _messagingService;

        #region Public Members

        /// <summary>
        /// Gets or sets the UserName of the user.
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName == value)
                    return;
                _UserName = value;
                OnPropertyChanged(GetPropertyName(() => UserName));
            }
        }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password == value)
                    return;
                _password = value;
                OnPropertyChanged(GetPropertyName(() => Password));
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// An event to notify the successfull log in event of a user.
        /// </summary>
        public event EventHandler<UserLoggedInEventArgs> UserLoggedIn
        {
            add { _userLoggedIn += value; }
            remove { _userLoggedIn -= value; }
        }

        #endregion

        #region Commands

        /// <summary>
        /// The commsn to let the user attempt log in.
        /// </summary>
        public ICommand TryLogInCommand { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises an instance of <see cref="LoginViewModel"/>.
        /// </summary>
        /// <param name="userRepository">An implemetation of <see cref="IUserRepository"/>. </param>
        /// <param name="messagingService"></param>
        public LoginViewModel(IUserRepository userRepository, IMessagingService messagingService)
            : base("Login")
        {
            if (userRepository == null)
                throw new ArgumentNullException("userRepository");
            if (messagingService == null)
                throw new ArgumentNullException("messagingService");
            _userRepository = userRepository;
            _messagingService = messagingService;
            TryLogInCommand = new RelayCommand(TryLoginIn, CanTryLogin);
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Tries loggin in the aplication.
        /// </summary>
        private void TryLoginIn()
        {
            try
            {
                var user = _userRepository.ValidateLoginAttempt(UserName, Password);
                if (user != null)
                {
                    if (_userLoggedIn != null)
                    {
                        _userLoggedIn(this, new UserLoggedInEventArgs(user));
                    }
                }
                else
                {
                    LogUtil.LogInfo("LoginViewModel", "TryLoginIn", string.Format("Failed login attempted for  UserName: {0}.", UserName));
                    _messagingService.ShowMessage(ErrorMessages.ERR_FAILED_LOGIN_MESSAGE);
                }
            }
            catch (Exception ex)
            {
                LogUtil.LogError("LoginViewModel", "TryLoginIn", ex);
                _messagingService.ShowMessage(ErrorMessages.ERR_APP_ERROR, DialogType.Error);
            }
        }

        /// <summary>
        /// Returns if the TryLogIn can execute.
        /// </summary>
        /// <returns></returns>
        private bool CanTryLogin()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }

        #endregion

        #region Members Variables

        private string _UserName;
        private string _password;
        private event EventHandler<UserLoggedInEventArgs> _userLoggedIn;

        #endregion
    }
}
