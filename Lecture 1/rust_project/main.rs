mod test_functions;
use test_functions::test1;

fn main() {
    test1::public_function();
    test1::call_private_function();
}
