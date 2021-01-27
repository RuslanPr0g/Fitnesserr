import Head from "next/head";
import Link from "next/link";
import Layout, { siteTitle } from "../components/layout";
import utilStyles from "../styles/utils.module.css";

export default function Home() {
  return (
    <Layout home>
      <Head>
        <title>{siteTitle}</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <section className={utilStyles.headingMd}>
        <p>
          Check out{" "}
          <Link href="/trainings/exercises">
            <a>exercises</a>
          </Link>{" "}
          or{" "}
          <Link href="/users/signup">
            <a>sign up</a>
          </Link>{" "}
          for free to get started your routine!
        </p>
      </section>
    </Layout>
  );
}
