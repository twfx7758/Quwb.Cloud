﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Website.Models
{
    public class UserData
    {
        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column UserAccount.UserID
         *
         * @mbg.generated
         */
        public int userid { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column UserAccount.UserName
         *
         * @mbg.generated
         */
        public String username { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column UserAccount.OpenID
         *
         * @mbg.generated
         */
        public String openid { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column UserAccount.Password
         *
         * @mbg.generated
         */
        public String password { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column UserAccount.Mobile
         *
         * @mbg.generated
         */
        public String mobile { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column UserAccount.LastLoginTime
         *
         * @mbg.generated
         */
        public String lastlogintime { get; set; }

        public List<UserShopRela> userShopRela { get; set; }

        public List<Customization> customizations { get; set; }
    }
}
