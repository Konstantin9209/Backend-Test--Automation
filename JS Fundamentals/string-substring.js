function findSubstringInText(word, text) {
    const lowerCaseWord = word.toLowerCase();
    const lowerCaseText = text.toLowerCase();

    if (lowerCaseText.includes(lowerCaseWord)) {
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }
}

// Example Usage:
const firstExampleWord = "javascript";
const firstExampleText = "JavaScript is the best programming language";
findSubstringInText(firstExampleWord, firstExampleText);

const secondExampleWord = "python";
const secondExampleText = "JavaScript is the best programming language";
findSubstringInText(secondExampleWord, secondExampleText);
