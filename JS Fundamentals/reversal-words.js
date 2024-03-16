function solve(words, template){
    'use strict';

    const separateWords = words.split(', ')
    const templateWords = template.split(' ')
    let result = ' ';

    for(const templateWord of templateWords){
        if (templateWord[0] === '*'){
            const correspondingWord = separateWords.find(x => x.length === templateWord.length)
            result += `${correspondingWord} `
        }else {
            result += `${templateWord} `
        }
    }
    console.log(result)
}