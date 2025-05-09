using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraClient.Settings
{
    /// <summary>
    /// Represents a setting that has been changed, including its name, old value, and new value.
    /// </summary>
    /// <remarks>
    /// This class is used to encapsulate information about a changed setting, such as its name,
    /// the previous value, and the updated value. It is typically utilized in event handling
    /// scenarios where changes to settings need to be tracked or processed.
    /// </remarks>
    public class ChangedSetting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangedSetting"/> class.
        /// </summary>
        public ChangedSetting()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangedSetting"/> class with the specified name, old value, and new value.
        /// </summary>
        /// <param name="name">The name of the setting that has changed.</param>
        /// <param name="oldValue">The previous value of the setting. Can be <c>null</c>.</param>
        /// <param name="newValue">The new value of the setting.</param>
        public ChangedSetting(string name, object? oldValue, object newValue)
        {
            Name = name;
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Gets or sets the name of the setting that has been changed.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> representing the name of the changed setting.
        /// </value>
        /// <remarks>
        /// This property identifies the specific setting that has been modified. It is used
        /// in scenarios where tracking or handling changes to settings is required, such as
        /// in event-driven programming.
        /// </remarks>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the previous value of the setting before it was changed.
        /// </summary>
        /// <value>
        /// The old value of the setting. This value can be <c>null</c> if the setting did not have a previous value.
        /// </value>
        /// <remarks>
        /// This property is used to store the value of the setting prior to the change. It can be useful for
        /// tracking changes, debugging, or reverting to the previous state if needed.
        /// </remarks>
        public object? OldValue { get; set; }
        /// <summary>
        /// Gets or sets the new value of the setting after it has been changed.
        /// </summary>
        /// <value>
        /// The updated value of the setting. This value represents the state of the setting
        /// after the change has been applied.
        /// </value>
        /// <remarks>
        /// This property is used to store the new value of a setting when a change occurs.
        /// It is typically utilized in scenarios where the updated value needs to be processed
        /// or applied, such as updating camera configurations.
        /// </remarks>
        public object? NewValue { get; set; }
    }
}
