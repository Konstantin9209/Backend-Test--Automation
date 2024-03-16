function extractOddOccurrences(sentence) {
    // Split the sentence into words and convert to lowercase
    const words = sentence.toLowerCase().split(/\s+/);

    // Count the occurrences of each word
    const wordCounts = {};
    words.forEach(word => {
        wordCounts[word] = (wordCounts[word] || 0) + 1;
    });

    // Extract words with odd occurrences
    const oddOccurrences = Object.keys(wordCounts).filter(word => wordCounts[word] % 2 !== 0);

    // Join the results into a string
    const result = oddOccurrences.join(' ');

    return result;
}

// Example usage:
const input1 = 'Java C# Php PHP Java PhP 3 C# 3 1 5 C#';
const output1 = extractOddOccurrences(input1);
console.log(output1);

const input2 = 'Cake IS SWEET is Soft CAKE sweet Food';
const output2 = extractOddOccurrences(input2);
console.log(output2);
