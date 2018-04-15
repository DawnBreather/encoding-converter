# ./encoding-converter.exe {root_directory_path} {destination_encoding} {default_encoding} [file_extensoins]
# {root_directory_path} - path where the progam is searching for files to convert
# {destination_encoding} - destination encoding
# {default_encoding} - default encoding to use when opening the files
# [file_extensoins] - (optional) file extensions filter

./encoding-converter.exe "D:\Sources" utf-8 windows-1251 ".txt | .h | html"
./encoding-converter.exe "C:\Guides" utf-16 windows-1252

# OUTPUT example and explanation
# windows-1252 92% | .txt | simple-guide
# ==> Covnerted into utf-16

# windows-1252 - result of original encoding analysis
# 92% - confidence level
# .txt - file extension
# simple-guide - filename