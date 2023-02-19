class ReadParseFiles:

    def __init__(self):
        # Using name mangling to make the variable harder to access
        self.__fileFolder = "../files/"
        self.__textFileName = "text_file.txt"
        self.__jsonFileName = "json_file.json"
        self.__yamlFilename = "yaml_file.yaml"
        self.__csvFileName = "csv_file.csv"
        self.__xmlFileName = "xml_file.xml"
        self.__txtContents = None
        self.__jsonContents = None
        self.__yamlContents = None
        self.__csvContents = None
        self.__xmlContents = None

    def __call__(self):
        self.readParseTextFile()

    def fileFolder(self):
        return self.__fileFolder
    
    def textFileName(self):
        return self.__textFileName
    
    def jsonFileName(self):
        return self.__jsonFileName
    
    def yamlFileName(self):
        return self.__yamlFilename
    
    def csvFileName(self):
        return self.__csvFileName
    
    def xmlFileName(self):
        return self.__xmlFileName

    def readParseTextFile(self):
        filepath = f"{self.fileFolder()}{self.textFileName()}"

        with open(filepath, 'r') as file:
            self.__txtContents = file.read()

        print(self.__txtContents)