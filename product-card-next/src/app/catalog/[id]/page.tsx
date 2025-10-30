import { getCourseInfo } from "@/services/api";
import styles from "./page.module.css";
import CourseActions from "@/components/CourseActions/CourseActions";

export default async function CardPage({
  params,
}: {
  params: Promise<{ id: number }>;
}) {
  const { id } = await params;
  const course = await getCourseInfo(id);
  if (!course) {
    return <div>Course not found</div>;
  }
  const serializedCourse = {
    id: course.id,
    title: course.title,
    description: course.description,
    price: course.price,
  };
  return (
    <div className="container">
      <div className={styles.card_root}>
        <div className={styles.card_body}>
          <span className={styles.item_title}>{course.title}</span>
          <span className={styles.item_author}>{course.description}</span>
          <span className={styles.item_department}>{course.price}</span>
        </div>
        <CourseActions props={serializedCourse!}></CourseActions>
      </div>
    </div>
  );
}
