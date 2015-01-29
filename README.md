﻿# Enum Helper Class
- It helps binding an enum with description to ComboBox.
- Enum item description come from:
  1. localized resource (EnumType_ItemName)
  1. default resource (EnumType_ItemName)
  1. Description attribute (System.ComponentModel)
  1. Enum item name
- ExtraProperties attribute attaches a Dictionary&lt;string, string&gt;.
- GetExtraProperty extension method returns the value from the dictionary.

## Usage Sample
### Definition
```csharp
using System.ComponentModel;
using TakeAsh;

using NewLineCodesHelper = EnumHelper<NewLineCodes>;

public enum NewLineCodes {
  [ExtraProperties("Entity:'\n', SecondKey:'Not Used'")]
  [Description("Unix(LF)")]
  Lf,
  [ExtraProperties("Entity : \"\r\"")]
  [Description("Mac(CR)")]
  Cr,
  [ExtraProperties("Entity:\t'\r\n'")]
  [Description("Windows(CR+LF)")]
  CrLf,
}

Resource:
string NewLineCodes_Lf = "Unix(LF)";
string NewLineCodes_Cr = "Mac(CR)";
string NewLineCodes_CrLf = "Windows(CR+LF)";
```

### Binding an enum with description to ComboBox
```csharp
comboBox_NewLineCode_GalleryCategory.ItemsSource = NewLineCodesHelper.ValueDescriptionPairs;
comboBox_NewLineCode_Gallery.SelectedValuePath = "Value";
comboBox_NewLineCode_Gallery.SelectedValue = NewLineCodes.CrLf;

var newLineCode = (NewLineCodes)comboBox_NewLineCode_Gallery.SelectedValue;
var newLineEntity = newLineCode.GetExtraProperty("Entity");

var newLineEntities = NewLineCodesHelper.GetAllExtraProperties("Entity");
```

## EnumHelper<TEnum> Public Methods
- void Init()
- TEnum GetValueFromName(string name)
- TEnum GetValueFromDescription(string description)
- string[] GetAllExtraProperties(string key)
- bool IsDefined(int value)
- bool TryParse (string value, out TEnum result)
- string ToDescription(TEnum en)
- string GetAssemblyName()

## EnumHelper<TEnum> Public Properties
- TEnum[] Values [get]
- string[] Names [get]
- string[] Descriptions [get]
- ValueDescriptionPair[] ValueDescriptionPairs [get]

## EnumExtensionMethods Public Methods
- string ToDescription(this Enum en)
- string GetExtraProperty(this Enum en, string key)
- string GetAssemblyName(this Enum en)

## Link
- [C# 3.0 : using extension methods for enum ToString - I know the answer (it's 42) - MSDN Blogs](http://blogs.msdn.com/b/abhinaba/archive/2005/10/21/483337.aspx)
- [C# の enum に関連する小技。 - Qiita](http://qiita.com/hugo-sb/items/38fe86a09e8e0865d471)
- [[C#] 何故 enum に拘りたくなるのか？ | Moonmile Solutions Blog](http://www.moonmile.net/blog/archives/3666)
- [c# - Localizing enum descriptions attributes - Stack Overflow](http://stackoverflow.com/questions/569298/)
- [unit testing - .NET NUnit test - Assembly.GetEntryAssembly() is null - Stack Overflow](http://stackoverflow.com/questions/4337201/)
