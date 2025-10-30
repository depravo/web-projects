import Course from "./Course";

export interface IButtonProps {
  text: string;
  link: string;
  type?: string;
  variant?: string;
  handleClick?: () => void;
}
