let negate = (f, n) => !f(n)

let isPositive = (n) => n > 0

console.log(isPositive(-1))
console.log(isPositive(0))
console.log(isPositive(1))

console.log(negate(isPositive, -1))
console.log(negate(isPositive, 0))
console.log(negate(isPositive, 1))
