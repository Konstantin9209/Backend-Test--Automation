function printSubstring(inputString, startIndex, count) {
    if (startIndex < 0 || startIndex >= inputString.length) {
        console.log("Invalid starting index");
        return;
    }

    const resultSubstring = inputString.substring(startIndex, startIndex + count);

    console.log(resultSubstring);
}

printSubstring('ASentence', 1, 8);
printSubstring('SkipWord', 4, 7);
