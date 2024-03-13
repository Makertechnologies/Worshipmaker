using System.Text.Json;

namespace Worshipmaker.Core
{
    public class BaseCustomizableEntity : BaseEntity
    {
        private Dictionary<string, string> _CustomProperties;

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        public BaseCustomizableEntity() : base()
        {
            _CustomProperties = [];
        }

        protected string CustomProperties
        {
            get
            {
                _CustomProperties ??= [];
                return JsonSerializer.Serialize(_CustomProperties);
            }
            set
            {
                var obj = JsonSerializer.Deserialize<Dictionary<string, string>>(value);
                _CustomProperties = obj ??= [];
            }
        }

        /// <summary>
        /// Determines if a custom property for the specified key exists.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool CustomPropertyExists(string key)
        {
            return _CustomProperties != null && _CustomProperties.ContainsKey(key);
        }

        /// <summary>
        /// Returns a custom property value for the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string CustomPropertyGet(string key)
        {
            if (_CustomProperties != null && _CustomProperties.ContainsKey(key))
            {
                return _CustomProperties[key];
            }
            return string.Empty;
        }

        /// <summary>
        /// Creates or updates a custom property.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void CustomPropertySet(string key, string value)
        {
            _CustomProperties ??= [];
            if (_CustomProperties.ContainsKey(key))
            {
                // Update existing
                _CustomProperties[key] = value;
            }
            else
            {
                // Create new
                _CustomProperties.Add(key, value);
            }
        }
    }
}