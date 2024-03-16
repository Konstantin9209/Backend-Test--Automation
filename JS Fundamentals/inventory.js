function createHeroRegister(heroData) {
    // Parse hero data and store it in an array
    const heroes = heroData.map(hero => {
        const [name, level, items] = hero.split(' / ');
        return {
            name: name.trim(),
            level: Number(level),
            items: items.split(', ').map(item => item.trim())
        };
    });

    // Sort heroes by level in ascending order
    heroes.sort((a, b) => a.level - b.level);

    // Print the formatted hero data
    heroes.forEach(hero => {
        console.log(`Hero: ${hero.name}\nlevel => ${hero.level}\nitems => ${hero.items.join(', ')}\n`);
    });
}

// Example usage:
const input1 = [
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
];

createHeroRegister(input1);

const input2 = [
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
];

createHeroRegister(input2);
