'use client'
import styles from "./page.module.css";
import NumberToText from "./components/numbertotext";

export default function Home() {
  return (
    <main className={styles.main}>
      <div className={styles.description}>
        <NumberToText />
      </div>
    </main>
  );
}
