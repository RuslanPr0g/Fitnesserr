import Head from "next/head";
import styles from "../styles/Home.module.css";
import Link from "next/link";

export default function Home() {
  return (
    <div className={styles.container}>
      <Head>
        <title>Fitnesserr</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <main className={styles.main}>
        <h1 className={styles.title}>
          Welcome to FITNESSERR, guest, see our{" "}
          <Link href="/trainings/exercises">
            <a className="link">Exercises</a>
          </Link>{" "}
          and{" "}
          <Link href="/users/signup">
            <a>SignUP</a>
          </Link>{" "}
          for free!
        </h1>
        <br />
        <br />
        <br />
        <img src="/vercel.svg" alt="Vercel Logo" className="logo" />
      </main>
    </div>
  );
}
