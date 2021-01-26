import Link from "next/link";
import Layout from "../../components/layout";

export default function Exercises() {
  return (
    <Layout>
      <h1>Hello!</h1>
      <br />
      <strong>Sign Up here.</strong>
      <h2>
        <Link href="/">
          <a>Back to home</a>
        </Link>
      </h2>
    </Layout>
  );
}
