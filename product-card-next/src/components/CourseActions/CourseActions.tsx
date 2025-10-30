"use client";

import Course from "@/types/Course";
import { IButtonProps } from "@/types/IButtonProps";
import CustomButton from "../UI/Button/CustomButton";
import { deleteCourse, editCourse } from "@/services/api";
import "./course-actions.css";
import { useState } from "react";
import EditCourseForm from "../EditCourseForm/EditCouresForm";

interface CourseData {
  id: number;
  title: string;
  description: string;
  price: number;
}

export default function CourseActions({ props }: { props: CourseData }) {
  const course = new Course(
    props.id,
    props.title,
    props.description,
    props.price
  );
  const [isEditing, setIsEditing] = useState(false);
  const [currentCourse, setCurrentCourse] = useState<Course>(course);
  const handleUpdate = async () => {
    setIsEditing(true);
  };

  const handleDelete = async () => {
    await deleteCourse(course.id);
  };

   const handleSave = async (updatedCourse: Course) => {
    try {
      console.log(updatedCourse);
      await editCourse(updatedCourse);
      
      setCurrentCourse(updatedCourse);
      setIsEditing(false);
    } catch (error) {
      console.error("Failed to update course:", error);
      alert("Failed to update course");
    }
  };
  const handleCancel = () => {
    setIsEditing(false);
  };


  const btnDel: IButtonProps = {
    text: "Delete",
    link: "../catalog",
    variant: "secondary",
    handleClick: handleDelete,
  };
  const btnUpd: IButtonProps = {
    text: "Update",
    link: "",
    variant: "secondary",
    handleClick: handleUpdate,
  };

   if (isEditing) {
    return (
      <div className="container">
        <h3>Edit Course</h3>
        <EditCourseForm
          course={currentCourse}
          onSave={handleSave}
          onCancel={handleCancel}
        />
      </div>
    );
  }

  return (
    <div className="card_buttons">
      <CustomButton buttonProps={btnUpd} />
      <CustomButton buttonProps={btnDel} />
    </div>
  );
}
