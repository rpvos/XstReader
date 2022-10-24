# XstReader
XstReader is an open source viewer for Microsoft Outlook’s .ost and .pst files, written entirely in C#, with no dependency on any Microsoft Office components.

It presents as a classic mail viewer, with configurable layout:

![XstReader ScreenShot](https://raw.githubusercontent.com/iluvadev/XstReader/master/docs/img/XstReader-Screenshot01.png)
![XstReader ScreenShot](https://raw.githubusercontent.com/iluvadev/XstReader/master/docs/img/XstReader-Screenshot01_2.png)

XstReader goes beyond Outlook in that it will allow you to open .ost files, which are the caches created by Outlook to hold a local copy of a mailbox. Wanting to read an .ost file as the original motivation for this project: now it also as the ability to export the messages.

You can export any message (email, Contact, Appointment, Task):
* As a single html file, with all the attachments and all available information embedded in the file, to inspect all available information with a single file.
* As .msg file, to import later in Outlook
* With the Original format, only body, without headers

XstReader is based on Microsoft’s documentation of the Outlook file formats in [MS-PST], first published in 2010 as part of the anti-trust settlement with the DOJ and the EU: <https://msdn.microsoft.com/en-us/library/ff385210(v=office.12).aspx>

## Installation
To install a binary:
1. Choose a release, then download the XstReader-[release].zip file attached to it.
2. Extract the contents of the zip file to a programs folder.
3. Run XstReader.App.exe, and create shortcuts to it as required.


## More information
* [Readme](./README.md)
* [XstReader](./XstReader.md)
* [XstExporter](./XstExporter.md)
* [XstReader.Api](./XstReader.Api.md)
* [Release Notes](./ReleaseNotes.md)
* [License](./license.md)

## License
Distributed under the MS-PL license. See [license](license.md) for more information.
