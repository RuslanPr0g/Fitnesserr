import Link from "next/link";
import Head from "next/head";
import Layout from "../../components/layout";

export default function Exercises() {
  return (
    <Layout home="/">
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
    </Layout>
  );
}

export default function Home(props) { ... }

export async function getStaticProps() {
  // Get external data from the file system, API, DB, etc.
  const data = ...

  // The value of the `props` key will be
  //  passed to the `Home` component
  return {
    props: ...
  }
}