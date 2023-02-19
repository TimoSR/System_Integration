from read_parse_files import ReadParseFiles

class Main:
    def __init__(self):
        self.__readParseFiles = ReadParseFiles()

    def run(self):
        self.__readParseFiles.readParseTextFile()

if __name__ == "__main__":
    main = Main()
    main.run()