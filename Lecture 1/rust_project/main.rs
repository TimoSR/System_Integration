mod test_functions;
mod shape;
mod person;

use shape::*;
use test_functions::*;
use person::*;

fn main() {

    // with modules rust you can make rust pretty!

    // no modulepath ::

    public_function();
    let rectangle = Rectangle { width: 5.0, height: 10.0 };
    println!("Rectangle width: {}", rectangle.width());
    println!("Rectangle area: {}", rectangle.area());
    println!("Rectangle perimeter: {}", rectangle.perimeter());
    
    // with modulepath :: in case of library naming overlap
    
    test_functions::call_private_function();
    let rectangle = shape::Rectangle { width: 5.0, height: 10.0 };
    println!("Rectangle width: {}", rectangle.width);
    println!("Rectangle area: {}", rectangle.area());
    println!("Rectangle perimeter: {}", rectangle.perimeter());

    println!("Test {}", rectangle.width());

    // Testing person

    let alice = Person {
        name: String::from("Alice"),
        age: 30,
    };

    let alice_with_job = PersonWithJob::new(alice, String::from("Software Developer"));

    alice_with_job.say_hello_with_job();

}