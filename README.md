# XML Helper

[![Build status](https://ci.appveyor.com/api/projects/status/53r98dh884p6bg4r?svg=true)](https://ci.appveyor.com/project/madskristensen/XHelper)

Download this extension from the [VS Gallery](https://visualstudiogallery.msdn.microsoft.com/845a87b1-3bd7-43a4-871d-0458d9fce206)
or get the [CI build](http://vsixgallery.com/extension/d7c3f904-cc5a-4d47-aa25-81fb7c36df89/).

---------------------------------------

Remove all comments in any file with a click of a button.
Can also remove #regions and preserve XML Doc comments.

See the [changelog](CHANGELOG.md) for changes and roadmap.

## Features

1. Remove all comments in a document
1. Remove all XML Doc comments
  - _Example_ `/// <summary>`
1. Remove all except XML Doc comments
1. Remove all task comments
  - _Example_ `// TODO: fix this`
1. Remove all except task comments
1. Remove #regions

Find the commands in the **Edit** top level menu.

![Top level menu](art/top-menu.png)

## Examples
Here are some examples of before and after the comments have
been removed

### JSON

**Before**:
```javascript
{
	// Single-line comment
	"foo": {
		/*
		multi
        line
        comment
		*/
		"prop": 12
	}
}
```

**After**:
```javascript
{
	"foo": {
		"prop": 12
	}
}
```

### CSharp

**Before**:
```c#
/// <summary>
/// Foo bar
/// </summary>
public class Class1
{
    /*
    multi
    line
    comment
    */
    void Hat()
    {
        //single-line comment 
        for (int i = 0; i < 10; i++)
        {
            System.Diagnostics.Debug.Write(i); // same-line comment
        }
    }
}
```

**After**:
```c#
public class Class1
{
    void Hat()
    {
        for (int i = 0; i < 10; i++)
        {
            System.Diagnostics.Debug.Write(i);   
        }
    }
}   
```

## Contribute
Check out the [contribution guidelines](.github/CONTRIBUTING.md)
if you want to contribute to this project.

For cloning and building this project yourself, make sure
to install the
[Extensibility Tools 2015](https://visualstudiogallery.msdn.microsoft.com/ab39a092-1343-46e2-b0f1-6a3f91155aa6)
extension for Visual Studio which enables some features
used by this project.

## License
[Apache 2.0](LICENSE)