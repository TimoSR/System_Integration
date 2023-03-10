import ReadParseFiles from './readParseFiles';

const reader = new ReadParseFiles();

async function main() {

  await reader.readParseTextFile();
  await reader.readParseJsonFile();
  await reader.readParseYamlToJson();
  await reader.readParseCsvToJson();
  await reader.readParseXmlToJson();

  // Printing the modified variables modified by the methods above

  console.log(reader);

}

main();