This example shows two aspects that cause a field or a property to be backed by a persistent storage:

* `RegistryValueAttribute` is an aspect that persists a field or property into a Windows registry value.
  It is useful in Windows applications that use a lot of registry settings. 

* `AppSettingValuesAttribute` retrieves the value of a field or property from the `<appSettings>`
section of `app.config` or `web.config`.

Both aspects work in a similar way. Both aspect classes contain a field named `isFetched`, which is set
to `true` when the value has already been fetched from the storage. This is an optimization that avoids 
the application from retrieving and converting the value several times. When the field or property value
is retrieved, but the `isFetched` field is set to `false`, then the aspect retrieves the value from
the storage, converts it from a `string` to the field/property type, and sets the `isFetched` field
to `true`.

The `RegistryValueAttribute` is modifies the registry value when the value of the target field
or property is set. However, the `AppSettingsValueAttribute` is not allowed to change the content
of the `app.config` or `web.config` file. Therefore, changing the value of the target field or property
is forbidden after the field or property value has been retrieved. However, changing the value *before*
the first retrieval is allowed: this is how you should set the default value of this setting.

Both aspect classes use the `[MulticastAttributeUsage(TargetMemberAttributes = MulticastAttributes.Static)]`
custom attribute to specify that they can be applied only to static fields and properties.

In this example, we apply the `RegistryValueAttribute` custom attribute to the `TestRegistryValues` class, which
has the effect to persist all static fields of this class to registry. We're doing the same with the `AppSettingsValueAttribute` custom attribute and the `TestAppSettingsValue` class.
If you want to persist only specific fields or properties, remove the custom attribute from the class
and add it to these specific fields or properties.



## Demonstrated techniques

The aspect demonstrates the use of `LocationInterceptionAspect` to enhance fields and properties,
and `[MulticastAttributeUsage]` to restrict the aspects to static fields or properties.
