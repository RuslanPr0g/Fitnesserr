import Link from "next/link";
import Head from "next/head";
import Layout from "../../components/layout";

export default function Exercises() {
  return (
    <Layout>
      <Head>
        <title>Exercises</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <ul>
        <li>First</li>
        <li>Second</li>
        <li>Third</li>
        <li>Fourth</li>
      </ul>

      <h2>
        <Link href="/">
          <a>Back to home</a>
        </Link>
      </h2>
    </Layout>
  );
}
