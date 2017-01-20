# XmlCreator

This is solely to create an XML-document where you can save for example settings for an application.

## How to use?
You need to create a new class that inherits "XmlCreator.XmlCreator".

```C#
public class MyXml : XmlCreator.XmlCreator
{
}
```

By inheriting this class you need to have a constructor with 1 string-parameter: a parameter for the name of the file. This file will be saved in your local AppData-folder.

```C#
public class MyXml : XmlCreator.XmlCreator
{
        public MyXml(string filename)
            : this(filename, String.Empty)
        {

        }
}
```

Next to the single parameter constructor you can also use a 2 string-parameters constructor: one parameter for the name of the file and another for the file path (if this must be different from the local AppData-folder).

```C#
public class MyXml : XmlCreator.XmlCreator
{
        public MyXml(string filename)
            : this(filename, String.Empty)
        {

        }
        
                public MyXml(string filename, string filepath)
            : base(filename, filepath)
        {

        }
}
```

The class "XmlCreator.XmlCreator" obligates to override the method "CreateDefaultXElement()". Upon creating the XML-document this will be the contents of the file.

Now all that is left is to do the other actions to create a file, like adding new elements to the XML or reading the values.

## Public properties
The XmlCreator-class has a total of 3 public properties:
- A string-value with the name of the file;
- A string-value with the name of the file with the full path to this very file;
- The XML-document itself.

The last property can be used to read and/or edit the elements in it.
