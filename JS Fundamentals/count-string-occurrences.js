function countWordOccurrences(text, targetWord) {
    const words = text.split(/\s+/);

    const wordCount = words.reduce((count, word) => {
        if (word === targetWord) {
            return count + 1;
        } else {
            return count;
        }
    }, 0);

    console.log(wordCount);
}
countWordOccurrences('This is a word and it also is a sentence', 'is');

countWordOccurrences('softuni is great place for learning new programming languages', 'softuni');
