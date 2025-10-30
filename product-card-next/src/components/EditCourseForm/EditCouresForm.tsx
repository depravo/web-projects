"use client";

import { useState } from "react";
import CustomButton from "@/components/UI/Button/CustomButton";
import "./edit-course-form.css";
import Course from "@/types/Course";

interface EditCourseFormProps {
  course: Course;
  onSave: (updatedCourse: Course) => Promise<void>;
  onCancel: () => void;
}

export default function EditCourseForm({ course, onSave, onCancel }: EditCourseFormProps) {
  const [formData, setFormData] = useState({
    title: course.title,
    description: course.description,
    price: course.price.toString(),
  });

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
      const updatedCourse = new Course(
        course.id,
        formData.title,
        formData.description,
        parseFloat(formData.price)
      );
      await onSave(updatedCourse);
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  return (
    <form onSubmit={handleSubmit} className="edit_form">
      <div className="formGroup">
        <label htmlFor="title">Title:</label>
        <input
          type="text"
          id="title"
          name="title"
          value={formData.title}
          onChange={handleChange}
          required
        />
      </div>
      
      <div className="formGroup">
        <label htmlFor="description">Description:</label>
        <textarea
          id="description"
          name="description"
          value={formData.description}
          onChange={handleChange}
          rows={4}
          required
        />
      </div>
      
      <div className="formGroup">
        <label htmlFor="price">Price:</label>
        <input
          type="number"
          id="price"
          name="price"
          value={formData.price}
          onChange={handleChange}
          step="0.01"
          min="0"
          required
        />
      </div>
      
      <div className="form_buttons">
        <CustomButton
          buttonProps={{
            text: "Cancel",
            link: "",
            variant: "secondary",
            handleClick: onCancel,
            type: "button"
          }}
        />
        <CustomButton
          buttonProps={{
            text: "Save Changes",
            link: "",
            variant: "primary",
            type: "submit",
            handleClick : () => {
                const form = document.querySelector(".edit_form") as HTMLFormElement;
                if(form) {
                    form.requestSubmit();
                }
            }
          }}
        />
      </div>
    </form>
  );
}