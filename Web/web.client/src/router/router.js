import {createRouter, createWebHistory} from "vue-router";
import WorkflowPage from "@/pages/WorkflowPage.vue";
import TaskPage from "@/pages/JobPage.vue";
import MainPage from "@/pages/MainPage.vue";
import StudioPage from "@/pages/StudioPage.vue";

const routes = [
	{
		path: '/',
		component: MainPage,
	},
	{
		path: '/workflows/',
		component: WorkflowPage,
	},
	{
		path: '/tasks/',
		component: TaskPage,
	},
	{
		path: '/studio/:id',
		component: StudioPage,
	}
]

const router = createRouter({
	routes,
	history: createWebHistory(),
})

export default router;