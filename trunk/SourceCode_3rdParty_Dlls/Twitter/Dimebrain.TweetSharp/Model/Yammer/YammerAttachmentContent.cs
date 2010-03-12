#region License

// TweetSharp
// Copyright (c) 2010 Daniel Crenna and Jason Diller
// 
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp.Model
{
    /// <summary>
    /// Represents the content of a yammer attachment
    /// </summary>
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class YammerAttachmentContent : PropertyChangedBase, IYammerModel
    {
        private long _size;
        private string _url;

        /// <summary>
        /// Gets or sets the size of the attachment content
        /// </summary>
        /// <value>The size.</value>
        [JsonProperty("size")]
#if !Smartphone
        [DataMember]
#endif
        public virtual long Size
        {
            get { return _size; }
            set
            {
                if (_size == value)
                {
                    return;
                }
                _size = value;
                OnPropertyChanged("Size");
            }
        }

        /// <summary>
        /// Gets or sets the URL of the attachment content.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("url")]
#if !Smartphone
        [DataMember]
#endif
        public virtual string Url
        {
            get { return _url; }
            set
            {
                if (_url == value)
                {
                    return;
                }
                _url = value;
                OnPropertyChanged("Url");
            }
        }
    }
}