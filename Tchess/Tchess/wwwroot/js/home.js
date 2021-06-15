let one = document.getElementById('cardone')
let two = document.getElementById("cardtwo")
let three = document.getElementById('cardthree')
let four = document.getElementById("cardfour")
one.addEventListener("mouseover", (e) => {
    one.classList.add("animate__rotateOut")
})
one.addEventListener("mouseout", (e) => {
    one.classList.remove("animate__rotateOut")
    one.classList.add("animate__rotateIn")
})
two.addEventListener("mouseover", (e) => {
    two.classList.add("animate__rotateOut")
})
two.addEventListener("mouseout", (e) => {
    two.classList.remove("animate__rotateOut")
    two.classList.add("animate__rotateIn")
})
three.addEventListener("mouseover", (e) => {
    three.classList.add("animate__rotateOut")
})
three.addEventListener("mouseout", (e) => {
    three.classList.remove("animate__rotateOut")
    three.classList.add("animate__rotateIn")
})
four.addEventListener("mouseover", (e) => {
    four.classList.add("animate__rotateOut")
})
four.addEventListener("mouseout", (e) => {
    four.classList.remove("animate__rotateOut")
    four.classList.add("animate__rotateIn")
})