import ArtItem from "@/types/ArtItem";
import Course from "@/types/Course";
import axios, { AxiosError } from "axios";
import https from "https";

const axiosInstance = axios.create({
  httpsAgent: new https.Agent({
    rejectUnauthorized: false
  })
});

export const getArts = async () => {
  try {
    const response = await axios.get(
      "https://collectionapi.metmuseum.org/public/collection/v1/search?q=departmentId=4&hasImages=true&limit=10"
    );
    return response;
  } catch (error) {
    const err = error as AxiosError;
  }
};

export const getArtInfo = async (artId: number) => {
  try {
    const response = await axios.get(
      `https://collectionapi.metmuseum.org/public/collection/v1/objects/${artId}`
    );
    return response;
  } catch (error) {
    console.log((error as AxiosError).message);
  }
};

export const loadArts = async () => {
  try {
    const artsData = await getArts();
    if (!artsData || !artsData.data.objectIDs) return [];

    const artIds = artsData.data.objectIDs.slice(0, 10);

    const artPromises = artIds.map((id: number) => getArtInfo(id));
    const artsDataArray = await Promise.all(artPromises);

    const artsArr: ArtItem[] = artsDataArray.map(
      (item) =>
        new ArtItem(
          item.data.objectID,
          item.data.primaryImageSmall,
          item.data.objectName,
          item.data.title,
          item.data.department,
          item.data.objectDate
        )
    );
    return artsArr;
  } catch (error) {
    return [];
  }
};

export const getCourses = async () => {
  try {
    const response = await axiosInstance.get("https://localhost:7192/api/courses/all");
    console.log(response.status);
    return response.data;
  } catch (error) {
    const err = error as AxiosError;
    console.log("Error message:", err.message);
  }
};

export const getCourseInfo = async (courseId: number) => {
  try {
    const response = await axiosInstance.get(
      `https://localhost:7192/api/courses/${courseId}`
    );
    console.log("Get: " + response.status);
    const course = new Course(
      response.data.id,
      response.data.title,
      response.data.description,
      response.data.price
    );
    return course;
  } catch (error) {
    const err = error as AxiosError;
    console.log("Error message:", err.message);
  }
};

export const editCourse = async (course: Course) => {
  try {
 const courseDto = {
      title: course.title,
      description: course.description,
      price: course.price
    };

    const response = await axiosInstance.put(
      `https://localhost:7192/api/courses/edit/${course.id}`, courseDto
    );
    console.log("Edit: " + response.status);
  } catch (error) {
    const err = error as AxiosError;
    console.log("Error message:", err.message);
  }
};

export const deleteCourse = async (courseId: number) => {
  try {
    const response = await axios.delete(`https://localhost:7192/api/courses/delete/${courseId}`);
    console.log("Delete: " + response.status);
  } catch (error) {
    const err = error as AxiosError;
    console.log("Error message:", err.message);
  }
};
