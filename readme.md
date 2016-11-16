# What is SecQDb?
The `SecQDb` library exposes data from SEC Financial Statement Data Sets, available [here](https://www.sec.gov/dera/data/financial-statement-data-sets.html). The data sets provide selected information extracted from exhibits to corporate financial reports filed with the Commission using eXtensible Business Reporting Language (XBRL).

# Getting Started
Working with the `SecQDb` library is straightforward:

1. Download a data set from the [SEC Financial Statement Data Sets page](https://www.sec.gov/dera/data/financial-statement-data-sets.html).
2. Unzip the data set files into a folder.
3. Reference the `JeffFerguson.SecQDb.dll` assembly in your .NET project.
4. Create an instance of the `JeffFerguson.SecQDb.QuarterlyDatabase` class. The class implements `IDisposable`, so the creation of the object should be wrapped in a `using` clause so that the data set files can be closed when the object is disposed.
5. Call `Load()` on the new `JeffFerguson.SecQDb.QuarterlyDatabase` object, passing in as a parameter the path to the folder in which the data set was unzipped.

```
public void SimpleExample()
{
    using (var qdb = new JeffFerguson.SecQDb.QuarterlyDatabase())
    {
        var loadSuccess = qdb.Load(@"C:\Users\You\Desktop\DataSetUnzipFolder");
    }
}
```

Once the document is loaded, you can use properties on the `QuarterlyDatabase` object to inspect the properties of the loaded database.

# Support for .NET Standard
The library builds against .NET Standard 1.6, which makes the code buildable on the following platforms:

* .NET Core 1.0
* .NET Framework 4.6.2
* Mono 4.6
* Xamarin.iOS 10.0
* Xamarin.Android 7.0
* Universal Windows Platform 10.0