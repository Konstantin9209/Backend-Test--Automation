function replaceWordWithStars(text, word) {
    const regex = new RegExp(word, 'g');

    const newText = text.replace(regex, match => '*'.repeat(match.length));

    console.log(newText);
}

replaceWordWithStars('A small sentence with some words', 'small');

replaceWordWithStars('Find the hidden word', 'hidden');
