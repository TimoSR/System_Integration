class Main {

    constructor() {}

    private str: string = "This is a random string";
    private buf:any;
    

    public encode () {
        this.buf = Buffer.from(this.str, "utf-8");
        console.log(this.buf);
    }

    public decode () {
        console.log(this.buf.toString());
    }

}

const main = new Main();
main.encode();
main.decode();