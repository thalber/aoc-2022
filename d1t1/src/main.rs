use std::fs;
use regex::{self, Regex, RegexBuilder};
//use std::

fn main() {
    for i in 0..15{
        example();
    }
}
fn example() {
    let mut x = 5;
    let mut y = &mut x;

    // This code causes undefined behavior, as it mutates
    // a variable that is borrowed by a mutable reference
    *y = 10;
    println!("{}, {}", y, *y)
}




