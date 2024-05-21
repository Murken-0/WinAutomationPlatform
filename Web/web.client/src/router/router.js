import {createRouter, createWebHistory} from "vue-router";
import WorkflowPage from "@/pages/WorkflowPage.vue";
import TaskPage from "@/pages/TaskPage.vue";
import MainPage from "@/pages/MainPage.vue";

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
	}
]

const router = createRouter({
	routes,
	history: createWebHistory(),
})

export default router;