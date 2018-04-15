Simple .NET Core console application to identify charset encoding and convert into the custom one.
Using [Mozilla Universal Charset Detector](http://mxr.mozilla.org/mozilla/source/extensions/universalchardet/src/) to identify the original charset.

So that can recognize the following charsets:

* UTF-8
* UTF-16 (BE and LE)
* UTF-32 (BE and LE)
* windows-1252 (mostly equivalent to iso8859-1)
* windows-1251 and ISO-8859-5 (cyrillic)
* windows-1253 and ISO-8859-7 (greek)
* windows-1255 (logical hebrew. Includes ISO-8859-8-I and most of x-mac-hebrew)
* ISO-8859-8 (visual hebrew)
* Big-5
* gb18030 (superset of gb2312)
* HZ-GB-2312
* Shift-JIS
* EUC-KR, EUC-JP, EUC-TW
* ISO-2022-JP, ISO-2022-KR, ISO-2022-CN
* KOI8-R
* x-mac-cyrillic
* IBM855 and IBM866
* X-ISO-10646-UCS-4-3412 and X-ISO-10646-UCS-4-2413 (unusual BOM)
* ASCII

## Usage
### Instruction
    ./encoding-converter.exe {root_directory_path} {destination_encoding} {default_encoding} [file_extensoins]
* **{root_directory_path}** - path where the progam is searching for files to convert
* **{destination_encoding}** - destination encoding
* **{default_encoding}** - default encoding to use when opening the files
* **[file_extensoins]** - (optional) file extensions filter

### Example
	./encoding-converter.exe "D:\Sources" utf-8 windows-1251 ".txt | .h | html"
	./encoding-converter.exe "C:\Guides" utf-16 windows-1252

### Output example and explanation
	windows-1252 92% | .txt | simple-guide
	==> Converted into utf-16
	
* **windows-1252** - result of original encoding analysis
* **92%** - confidence level
* **.txt** - file extension
* **simple-guide** - filename  

## License
Sure, free to use and share ^_^