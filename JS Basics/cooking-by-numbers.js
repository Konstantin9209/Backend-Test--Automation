function solve(
  rawNumber,
  firstOperation,
  secondOperation,
  thirdOperation,
  forthOperation,
  fifthOperation
) {
  "use strict";

  let number = parseInt(rawNumber, 10);

  if (firstOperation === "chop") {
    number = number / 2;
  } else if (firstOperation === "dice") {
    number = Math.sqrt(number);
  } else if (firstOperation === "spice") {
    number += 1;
  } else if (firstOperation === "bake") {
    number = number * 3;
  } else if (firstOperation === "fillet") {
    number = number * 0.8;
  }
  console.log(number);

  if (secondOperation === "chop") {
    number = number / 2;
  } else if (secondOperation === "dice") {
    number = Math.sqrt(number);
  } else if (secondOperation === "spice") {
    number += 1;
  } else if (secondOperation === "bake") {
    number = number * 3;
  } else if (secondOperation === "fillet") {
    number = number * 0.8;
  }
  console.log(number);

  if (thirdOperation === "chop") {
    number = number / 2;
  } else if (thirdOperation === "dice") {
    number = Math.sqrt(number);
  } else if (thirdOperation === "spice") {
    number += 1;
  } else if (thirdOperation === "bake") {
    number = number * 3;
  } else if (thirdOperation === "fillet") {
    number = number * 0.8;
  }
  console.log(number);

  if (forthOperation === "chop") {
    number = number / 2;
  } else if (forthOperation === "dice") {
    number = Math.sqrt(number);
  } else if (forthOperation === "spice") {
    number += 1;
  } else if (forthOperation === "bake") {
    number = number * 3;
  } else if (forthOperation === "fillet") {
    number = number * 0.8;
  }
  console.log(number);

  if (fifthOperation === "chop") {
    number = number / 2;
  } else if (fifthOperation === "dice") {
    number = Math.sqrt(number);
  } else if (fifthOperation === "spice") {
    number += 1;
  } else if (fifthOperation === "bake") {
    number = number * 3;
  } else if (fifthOperation === "fillet") {
    number = number * 0.8;
  }
    console.log(number);
  
}
solve('32', 'chop', 'chop', 'chop', 'chop', 'chop',)