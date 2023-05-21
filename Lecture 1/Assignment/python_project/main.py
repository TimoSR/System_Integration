from read_parse_files import ReadParseFiles

class Main:
    def __init__(self):
        self.__readParseFiles = ReadParseFiles()

    def run(self):
        self.__readParseFiles.readParseTextFile()
        self.__readParseFiles.readParseJsonFile()
        self.__readParseFiles.readParseCsvToJson()

if __name__ == "__main__":
    main = Main()
    main.run()