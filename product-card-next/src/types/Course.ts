export default class Course {
  id: number;
  title: string;
  description: string;
  price: number;

  constructor(
    _id: number = 0,
    _title: string = "",
    _description: string = "",
    _price: number = 0
  ) {
    this.id = _id;
    this.title = _title;
    this.description = _description;
    this.price = _price;
  }
}
