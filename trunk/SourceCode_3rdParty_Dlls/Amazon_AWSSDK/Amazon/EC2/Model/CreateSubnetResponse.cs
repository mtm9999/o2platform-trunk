﻿namespace Amazon.EC2.Model
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    [XmlRoot(Namespace="http://ec2.amazonaws.com/doc/2009-11-30/", IsNullable=false)]
    public class CreateSubnetResponse
    {
        private Amazon.EC2.Model.CreateSubnetResult createSubnetResultField;
        private Amazon.EC2.Model.ResponseMetadata responseMetadataField;

        public bool IsSetCreateSubnetResult()
        {
            return (this.createSubnetResultField != null);
        }

        public bool IsSetResponseMetadata()
        {
            return (this.responseMetadataField != null);
        }

        public string ToXML()
        {
            StringBuilder sb = new StringBuilder(0x400);
            XmlSerializer serializer = new XmlSerializer(base.GetType());
            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize((TextWriter) writer, this);
            }
            return sb.ToString();
        }

        public CreateSubnetResponse WithCreateSubnetResult(Amazon.EC2.Model.CreateSubnetResult createSubnetResult)
        {
            this.createSubnetResultField = createSubnetResult;
            return this;
        }

        public CreateSubnetResponse WithResponseMetadata(Amazon.EC2.Model.ResponseMetadata responseMetadata)
        {
            this.responseMetadataField = responseMetadata;
            return this;
        }

        [XmlElement(ElementName="CreateSubnetResult")]
        public Amazon.EC2.Model.CreateSubnetResult CreateSubnetResult
        {
            get
            {
                return this.createSubnetResultField;
            }
            set
            {
                this.createSubnetResultField = value;
            }
        }

        [XmlElement(ElementName="ResponseMetadata")]
        public Amazon.EC2.Model.ResponseMetadata ResponseMetadata
        {
            get
            {
                return this.responseMetadataField;
            }
            set
            {
                this.responseMetadataField = value;
            }
        }
    }
}

