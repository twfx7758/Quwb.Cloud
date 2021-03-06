﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Website.Models
{
    public class LogInfo
    {
        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column LogInfo.LogID
         *
         * @mbg.generated
         */
        public int logid { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column LogInfo.SystemID
         *
         * @mbg.generated
         */
        public int systemid { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column LogInfo.ModuleID
         *
         * @mbg.generated
         */
        public int moduleid { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column LogInfo.InfoID
         *
         * @mbg.generated
         */
        public string infoid { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column LogInfo.IP
         *
         * @mbg.generated
         */
        public string ip { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column LogInfo.AccessTime
         *
         * @mbg.generated
         */
        public String accesstime { get; set; }

        /**
         *
         * This field was generated by MyBatis Generator.
         * This field corresponds to the database column LogInfo.IsActive
         *
         * @mbg.generated
         */
        public short isactive { get; set; }
    }
}
