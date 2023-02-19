pub mod test1 {
    pub fn public_function() {
        println!("Hello World!");
    }

    fn private_function() {
        println!("This is a private function");
    }

    pub fn call_private_function() {
        private_function();
    }
}
