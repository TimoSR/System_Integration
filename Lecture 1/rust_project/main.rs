//Creates a new module from referenced code

mod test_functions;
mod shape;
mod person;

// Imports the functionality from the modules has option of alias
// alias e.g. "use shape as shp;"

use shape::*;
use test_functions::*;
use person::*;


fn main() {

    // with modules rust you can make rust pretty!

    // no modulepath ::

    let rectangle = Rectangle { width: 5.0, height: 10.0 };
    println!("Rectangle width: {}", rectangle.width());
    println!("Rectangle area: {}", rectangle.area());
    println!("Rectangle perimeter: {}", rectangle.perimeter());
    
    // with modulepath :: in case of library naming overlap
    
    let rectangle = shape::Rectangle { width: 5.0, height: 10.0 };
    println!("Rectangle width: {}", rectangle.width);
    println!("Rectangle area: {}", rectangle.area());
    println!("Rectangle perimeter: {}", rectangle.perimeter());

    println!("Test {}", rectangle.width());

    // An example of inheritance as composition

    let alice = Person {
        name: String::from("Alice"),
        age: 30,
    };

    let alice_with_job = PersonWithJob::new(alice, String::from("Software Developer"));

    alice_with_job.say_hello_with_job();

    //There is some casses where you could use references to make your code more readable
    // Lets say if I had a api::get, api::post, api::update, api::delete. 

    talking_alot::public_function();
    quite_type::call_private_function();

}