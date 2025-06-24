# Interception.DiscordSpy

Unturned RocketMod plugin that sends a result screenshot of /spy command to your Discord text channel via webhook
	
A part of [Interception.Module](https://github.com/interception-plugins/Interception.Module) example plugins

## Configuration

```xml
<?xml version="1.0" encoding="utf-8"?>
<config xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <webhook_url>0_o</webhook_url>
  <webhook_settings username="Interception's Unturned Spy Bot" avatar_url="https://sun9-32.userapi.com/impg/rSFId7czTetdDX6BKpqMMZbb6Rt1yNZsKKHbPg/L5jmIUatvhg.jpg?size=736x736&amp;quality=95&amp;sign=a245352bd74d713be44df3d66ff985f5&amp;type=album">
    <embeds />
    <flags>
      <webhook_flag>suppress_notifications</webhook_flag>
    </flags>
    <files />
  </webhook_settings>
</config>
```

## Translations

```xml
<?xml version="1.0" encoding="utf-8"?>
<Translations xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Translation Id="on_spy" Value="Screenshot for player &quot;{0}&quot; [{1}]" />
</Translations>
```