import { getCourses } from "@/services/api";
import Catalog from "@/components/Catalog/Catalog";
import CustomHeader from "@/components/Header/CustomHeader";

export default async function CatalogPage() {
  const courses = await getCourses();

  return (
    <>
      {/* <CustomHeader pageType={"catalog-page"}></CustomHeader> */}
      <Catalog items={courses} />
    </>
  );
}
