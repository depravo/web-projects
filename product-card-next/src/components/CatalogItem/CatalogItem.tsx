import React from "react";
import "./catalog-item.css";
import Course from "@/types/Course";
import Link from "next/link";

export default function CatalogItem({ item }: { item: Course }) {
  return (
    <div className="card">
      <Link href={`/catalog/${item.id}`} className="card_link">
      <div className="card_body">
        <span className="item_title">{item.title}</span>
        <span className="item_author">{item.description}</span>
        <span className="item_department">{item.price} $</span>
      </div>
      </Link>
    </div>
  );
}
